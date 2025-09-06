using AutoMapper;
using Core.UnitOfWorks;
using Core.Utilities.Results;
using LM.Business.Abstract;
using LM.DataAccess.Abstract;
using LM.Entity.Concrete;
using LM.Entity.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Business.Concrete;

public class UserManager : IUserServ
{
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserManager(IUserRepo userRepo, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IDataResult<UserResponseDto>> AddAsync(UserCreateRequestDto dto)
    {
        try
        {
            var user = _mapper.Map<User>(dto);
            await _userRepo.AddAsync(user);
            await _unitOfWork.CommitAsync();
            var userResponse = _mapper.Map<UserResponseDto>(user);
            return (IDataResult<UserResponseDto>)(new SuccesDataResult<UserResponseDto>(userResponse, "User added successfully."));
        }
        catch (Exception e)
        {

            return (IDataResult<UserResponseDto>)new ErrorDataResult<UserResponseDto>(e.Message);
        }
    }

    public Task<IDataResult<IEnumerable<UserResponseDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<UserResponseDto>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<User>> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<IEnumerable<User>>> GetUsersByFirstNameAsync(string firstName)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<IEnumerable<User>>> GetUsersByLastNameAsync(string lastName)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> RemoveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateAsync(UserUpdateRequestDto dto)
    {
        throw new NotImplementedException();
    }
}
