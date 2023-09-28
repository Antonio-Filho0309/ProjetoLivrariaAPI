using AutoMapper;
using ProjetoLivrariaAPI.Dtos;
using ProjetoLivrariaAPI.Models;

namespace ProjetoLivrariaAPI.Helpers {
    public class ProjetoLivrariaProfile : Profile {

        public ProjetoLivrariaProfile()
        {
            //Usuário
            CreateMap<User, UserDto>().ReverseMap();

            //Editora
<<<<<<< HEAD
            CreateMap<Publisher, PublisherDto>().ReverseMap();

            //Livro  
            CreateMap<Book , CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
=======
            CreateMap<Publisher, PublisherDto>();
            CreateMap<PublisherDto, Publisher>();
>>>>>>> parent of fa3b0b8 (muda tudo)
        }
    }
}
