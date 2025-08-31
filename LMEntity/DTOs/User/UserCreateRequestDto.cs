using Core.Entities;

namespace LM.Entity.DTOs.User;

public sealed record UserCreateRequestDto(
    string FirstName,
    string LastName,
    string PhoneNumber
    ) : ICreateDto;


