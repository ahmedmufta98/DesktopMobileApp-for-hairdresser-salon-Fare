using AutoMapper;
using eHairdresserSalonFare.Api.Database;
using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model.Requests.User;
using eHairdresserSalonFareBugojno.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace eHairdresserSalonFare.Api.Repository
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        private static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public Model.User Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, password);
                if (newHash == user.PasswordHash)
                {
                     return _mapper.Map<Model.User>(user);
                }
            }
            return null;
        }

        public Model.User Login(UserLoginRequest request)
        {
            var entity = _context.Users.Include(i => i.Role).FirstOrDefault(x => x.Username == request.Username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.PasswordSalt, request.Password);

            if (hash != entity.PasswordHash)
            {
                return null;
            }

            return _mapper.Map<Model.User>(entity);
        }

        public Model.User Register(UserUpsertRequest request)
        {
            var entity = _mapper.Map<eHairdresserSalonFareBugojno.Database.User>(request);


            if (request.Password != request.PasswordConfirm)
            {
                throw new Exception("Password and password confirm are not same!");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);

            _context.Users.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }

        public Model.User Insert(UserUpsertRequest model)
        {
            eHairdresserSalonFareBugojno.Database.User user = _mapper.Map<eHairdresserSalonFareBugojno.Database.User>(model);

            _context.Add(user);

            if (model.Password != model.PasswordConfirm)
            {
                throw new Exception("Password and password confirm are not same!");
            }

            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordSalt, model.Password);
            _context.SaveChanges();

            return _mapper.Map<Model.User>(user);
        }

        public IEnumerable<Model.User> Get(UserSearchRequest request)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(request?.LastName))
            {
                query = query.Where(x => x.LastName.Contains(request.LastName));
            }

            if (!string.IsNullOrWhiteSpace(request?.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            return _mapper.Map<IEnumerable<Model.User>>(query.Where(x => x.RoleId == 2).ToList());
        }

        public Model.User GetById(int id)
        {
            return _mapper.Map<Model.User>(_context.Users.Find(id));
        }

        public Model.User Update(int id, UserUpsertRequest model)
        {
            var entity = _context.Users.Find(id);
            if (!string.IsNullOrEmpty(model.Password))
            {
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, model.Password);
            }

            _mapper.Map(model, entity);
            _context.Users.Attach(entity);
            _context.Users.Update(entity);
            _context.SaveChanges();

            return _mapper.Map<Model.User>(entity);
        }

        public Model.User Delete(int id)
        {
            eHairdresserSalonFareBugojno.Database.User user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return _mapper.Map<Model.User>(user);
        }

        public Model.User GetByUsername(UserLoginRequest request)
        {
            return _mapper.Map<Model.User>(_context.Users.FirstOrDefault(u => u.Username == request.Username && u.RoleId==1));
        }

        public IEnumerable<Model.User> GetClients()
        {
            throw new NotImplementedException();
        }

        public List<Model.Payment> GetPaymentsOfUser(int userId)
        {
            List<Payment> payments = _context.Payments.Where(p => p.UserId == userId).ToList();

            if (payments.Count == 0)
            {
                return null;
            }

            return _mapper.Map<List<Model.Payment>>(payments);
        }
    }
}
