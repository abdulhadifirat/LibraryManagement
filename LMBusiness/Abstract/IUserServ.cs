using Core.Business;
using Core.Utilities.Results;
using LM.Entity.Concrete;
using LM.Entity.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Abstract;

public interface IUserServ : IGenericServ<User, UserResponseDto, UserCreateRequestDto, UserUpdateRequestDto, UserDetailResponseDto>
{
    Task<IDataResult<IEnumerable<User>>> GetUsersByFirstNameAsync(string firstName);
    Task<IDataResult<IEnumerable<User>>> GetUsersByLastNameAsync(string lastName);
    Task<IDataResult<User>> GetUserByPhoneNumberAsync(string phoneNumber);
}
