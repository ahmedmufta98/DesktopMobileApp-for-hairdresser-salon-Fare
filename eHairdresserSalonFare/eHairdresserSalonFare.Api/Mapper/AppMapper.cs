using AutoMapper;
using eHairdresserSalonFare.Api.Database;
using eHairdresserSalonFareBugojno.Database;

namespace eHairdresserSalonFare.Api.Mapper
{
    public class AppMapper:Profile
    {
        public AppMapper()
        {
            CreateMap<HairdresserSalon, Model.HairdresserSalon>().ReverseMap();
            CreateMap<HairdresserSalon, Model.Requests.HairdresserSalon.HairdresserSalonUpdateRequest>().ReverseMap();
            CreateMap<Model.HairdresserSalon, Model.Requests.HairdresserSalon.HairdresserSalonUpdateRequest>().ReverseMap();

            CreateMap<User, Model.User>().ReverseMap();
            CreateMap<User, Model.Requests.User.UserUpsertRequest>().ReverseMap();
            CreateMap<Model.User, Model.Requests.User.UserUpsertRequest>().ReverseMap();

            CreateMap<Hairdresser, Model.Hairdresser>().ReverseMap();
            CreateMap<Hairdresser, Model.Requests.Hairdresser.HairdresserUpsertRequest>().ReverseMap();
            CreateMap<Model.Hairdresser, Model.Requests.Hairdresser.HairdresserUpsertRequest>().ReverseMap();

            CreateMap<Hairstyle, Model.Hairstyle>().ReverseMap();
            CreateMap<Hairstyle, Model.Requests.Hairstyle.HairstyleUpsertRequest>().ReverseMap();
            CreateMap<Model.Hairstyle, Model.Requests.Hairstyle.HairstyleUpsertRequest>().ReverseMap();

            CreateMap<Payment, Model.Payment>().ReverseMap();
            CreateMap<Payment, Model.Requests.Payment.PaymentUpsertRequest>().ReverseMap();
            CreateMap<Model.Payment, Model.Requests.Payment.PaymentUpsertRequest>().ReverseMap();

            CreateMap<Sponsor, Model.Sponsor>().ReverseMap();
            CreateMap<Sponsor, Model.Requests.Sponsor.SponsorUpsertRequest>().ReverseMap();
            CreateMap<Model.Sponsor, Model.Requests.Sponsor.SponsorUpsertRequest>().ReverseMap();

            CreateMap<Associate, Model.Associate>().ReverseMap();
            CreateMap<Associate, Model.Requests.Associate.AssociateUpsertRequest>().ReverseMap();
            CreateMap<Model.Associate, Model.Requests.Associate.AssociateUpsertRequest>().ReverseMap();

            CreateMap<Notification, Model.Notification>().ReverseMap();
            CreateMap<Notification, Model.Requests.Notification.NotificationUpsertRequest>().ReverseMap();
            CreateMap<Model.Notification, Model.Requests.Notification.NotificationUpsertRequest>().ReverseMap();

            CreateMap<Booking, Model.Booking>().ReverseMap();
            CreateMap<Booking, Model.Requests.Booking.BookingUpsertRequest>().ReverseMap();
            CreateMap<Model.Booking, Model.Requests.Booking.BookingUpsertRequest>().ReverseMap();

            CreateMap<Payment, Model.Payment>().ReverseMap();
            CreateMap<Payment, Model.Requests.Payment.PaymentUpsertRequest>().ReverseMap();
            CreateMap<Model.Payment, Model.Requests.Payment.PaymentUpsertRequest>().ReverseMap();

            CreateMap<Rating, Model.Rating>().ReverseMap();
            CreateMap<Rating, Model.Requests.Rating.RatingInsertRequest>().ReverseMap();
            CreateMap<Model.Rating, Model.Requests.Rating.RatingInsertRequest>().ReverseMap();

            CreateMap<Comment, Model.Comment>().ReverseMap();
            CreateMap<Comment, Model.Requests.Comment.CommentInsertRequest>().ReverseMap();
            CreateMap<Model.Comment, Model.Requests.Comment.CommentInsertRequest>().ReverseMap();
        }
    }
}
