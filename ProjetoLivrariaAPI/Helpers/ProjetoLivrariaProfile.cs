using AutoMapper;
using ProjetoLivrariaAPI.Dtos.Book;
using ProjetoLivrariaAPI.Dtos.Publisher;
using ProjetoLivrariaAPI.Dtos.User;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Helpers
{
    public class ProjetoLivrariaProfile : Profile {

        public ProjetoLivrariaProfile()
        {
            //Usuário
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();   

            //Editora
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Publisher, CreatePublisherDto>().ReverseMap();
            CreateMap<Publisher , UpdatePublisherDto>().ReverseMap();
            CreateMap<Publisher, PublisherBookDto>().ReverseMap();

            //Livro
            CreateMap<Book , CreateBookDto>().ReverseMap();
            CreateMap<Book , UpdateBookDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();

            //Editora
            
        }
    }
}
