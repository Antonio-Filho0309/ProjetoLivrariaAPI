using AutoMapper;
using ProjetoLivrariaAPI.Models;
using ProjetoLivrariaAPI.Models.Dtos.Book;
using ProjetoLivrariaAPI.Models.Dtos.Publisher;
using ProjetoLivrariaAPI.Models.Dtos.Rental;
using ProjetoLivrariaAPI.Models.Dtos.User;

namespace ProjetoLivrariaAPI.Helpers
{
    public class ProjetoLivrariaProfile : Profile {

        public ProjetoLivrariaProfile()
        {
            //Usuário
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserRentalDto>().ReverseMap();
            CreateMap<User, UserDashDto>().ReverseMap();
            //Editora
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Publisher, CreatePublisherDto>().ReverseMap();
            CreateMap<Publisher , UpdatePublisherDto>().ReverseMap();
            CreateMap<Publisher, PublisherBookDto>().ReverseMap();
            CreateMap<Publisher, PublisherDashDto>().ReverseMap();   

            //Livro
            CreateMap<Book , CreateBookDto>().ReverseMap();
            CreateMap<Book , UpdateBookDto>().ReverseMap();
            CreateMap<Book, BookRentalDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book ,RentedDashDto>().ReverseMap();

            //Aluguel
            CreateMap<Rental, CreateRentalDto>().ReverseMap();
            CreateMap<Rental , RentalDto>().ReverseMap();
            CreateMap<Rental, UpdateRentalDto>().ReverseMap();
            CreateMap<Rental, RentalDashDto>().ReverseMap();
            
        }
    }
}
