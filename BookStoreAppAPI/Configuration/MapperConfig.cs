using AutoMapper;
using BookStoreAppAPI.Data;
using BookStoreAppAPI.Model.AuthorDTO;
using BookStoreAppAPI.Model.BookDTO;

namespace BookStoreAppAPI.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
            CreateMap<AuthorReadDTO, Author>().ReverseMap();

            CreateMap<BookCreateDTO, Book>().ReverseMap();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();
            CreateMap<Book, BookReadDTO>()
                .ForMember(q => q.AuthorName, q => q.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();
            CreateMap<Book, BookDetailsDTO>()
                .ForMember(q => q.AuthorName, q => q.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();
        }
    }
}
