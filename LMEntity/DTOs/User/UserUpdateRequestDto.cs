using Core.Entities;

namespace LM.Entity.DTOs.User;

public sealed record UserUpdateRequestDto(
    Guid Id,
    string FirstName,
    string LastName,
    string PhoneNumber
    ) : IUpdateDto;


