using AutoMapper;
using Core.UnitOfWorks;
using Core.Utilities.Results;
using LM.Business.Abstract;
using LM.DataAccess.Abstract;
using LM.Entity.Concrete;
using LM.Entity.DTOs.User;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IDataResult<IEnumerable<UserResponseDto>>> GetAllAsync()
    {
        try
        {
            var user = await _userRepo.GetAll().ToListAsync();
            if (user == null)
            {
                return (IDataResult<IEnumerable<UserResponseDto>>)new ErrorDataResult<IEnumerable<UserResponseDto>>("No users found.");
            }
            var userResponses = _mapper.Map<IEnumerable<UserResponseDto>>(user);
            return (IDataResult<IEnumerable<UserResponseDto>>)new SuccesDataResult<IEnumerable<UserResponseDto>>(userResponses);
        }
        catch (Exception)
        {

            return (IDataResult<IEnumerable<UserResponseDto>>)new ErrorDataResult<IEnumerable<UserResponseDto>>("An error occurred while retrieving users.");
        }
    }

    public async Task<IDataResult<UserResponseDto>> GetByIdAsync(Guid id)
    {
        try
        {
            var user = _userRepo.GetAll(u => u.Id == id);
            if (user == null)
            {
                return (IDataResult<UserResponseDto>)new ErrorDataResult<UserResponseDto>("User not found.");
            }
            var userResponse = _mapper.Map<UserResponseDto>(user);
            return (IDataResult<UserResponseDto>)new SuccesDataResult<UserResponseDto>(userResponse);
        }
        catch (Exception)
        {

            return (IDataResult<UserResponseDto>)new ErrorDataResult<UserResponseDto>("An error occurred while retrieving the user.");
        }
        
    }

    public async Task<IDataResult<User>> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        try
        {
            var user = await _userRepo.GetAsync(u => u.PhoneNumber == phoneNumber);
            if (user == null)
            {
                return (IDataResult<User>)new ErrorDataResult<User>("User not found.");
            }

            return (IDataResult<User>)new SuccesDataResult<User>(user);
        }
        catch (Exception)
        {
            return (IDataResult<User>)new ErrorDataResult<User>("An error occurred while retrieving the user.");
        }
    }

    public async Task<IDataResult<IEnumerable<User>>> GetUsersByFirstNameAsync(string firstName)
    {
        try
        {
            var user = await _userRepo.GetAsync(u => u.FirstName == firstName);
            if (user == null)
            {
                return (IDataResult<IEnumerable<User>>)new ErrorDataResult<User>("User not found.");
            }

            return (IDataResult<IEnumerable<User>>)new SuccesDataResult<User>(user);
        }
        catch (Exception)
        {
            return (IDataResult<IEnumerable<User>>)new ErrorDataResult<User>("An error occurred while retrieving the user.");
        }
    }

    public async Task<IDataResult<IEnumerable<User>>> GetUsersByLastNameAsync(string lastName)
    {
        try
        {
            var user = await _userRepo.GetAsync(u => u.LastName == lastName);
            if (user == null)
            {
                return (IDataResult<IEnumerable<User>>)new ErrorDataResult<User>("User not found.");
            }

            return (IDataResult<IEnumerable<User>>)new SuccesDataResult<User>(user);
        }
        catch (Exception)
        {
            return (IDataResult<IEnumerable<User>>)new ErrorDataResult<User>("An error occurred while retrieving the user.");
        }
    }

    public async Task<IResult> RemoveAsync(Guid id)
    {
        try
        {
            var user =  _userRepo.GetAsync(u => u.Id == id).Result;
            if (user == null)
            {
                return new ErrorResult("User not found.");
            }
            user.UpdatedAt = DateTime.Now;
            user.IsActive = false;
            _userRepo.Update(user);
           await _unitOfWork.CommitAsync();
            return new SuccesResult("User removed successfully.");
        }
        catch (Exception)
        {

            return new ErrorResult("An error occurred while removing the user.");
        }
    }

    public async Task<IResult> UpdateAsync(UserUpdateRequestDto dto)
    {
        try
        {
            var user = _mapper.Map<User>(dto);
            user.UpdatedAt = DateTime.Now;
            _userRepo.Update(user);
             await _unitOfWork.CommitAsync();
            return new SuccesResult("User updated successfully.");
        }
        catch (Exception)
        {

            return new ErrorResult("An error occurred while updating the user.");
        }
    }
}
