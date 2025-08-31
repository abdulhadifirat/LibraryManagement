using Core.Entities;

namespace LM.Entity.DTOs.User;

public sealed record UserDetailResponseDto(
    Guid Id,
    string FirstName,
    string LastName,
    string PhoneNumber,
    DateTime CreatedDate
    ) : IDetailDto;


