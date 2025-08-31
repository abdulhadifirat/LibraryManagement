using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.Entity.DTOs.User;

public sealed record UserResponseDto (
    Guid Id,
    string FirstName,
    string LastName,
    string PhoneNumber
    ) : IResponseDto;


