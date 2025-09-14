using AutoMapper;
using LM.Entity.Concrete;
using LM.Entity.DTOs.Book;
using LM.Entity.DTOs.Loan;
using LM.Entity.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Mappers;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Book, BookResponseDto>();
        CreateMap<Book, BookDetailResponseDto>();
        CreateMap<BookCreateRequestDto, Book>();
        CreateMap<BookUpdateRequestDto, Book>();

        CreateMap<User, UserResponseDto>(); 
        CreateMap<User, UserDetailResponseDto>();
        CreateMap<UserCreateRequestDto, User>();
        CreateMap<UserUpdateRequestDto, User>();

        CreateMap<Loan, LoanResponseDto>();
        CreateMap<Loan, LoanDetailResponseDto>();
        CreateMap<LoanCreateRequestDto, Loan>();
        CreateMap<LoanUpdateRequestDto, Loan>();


        
    }
}
