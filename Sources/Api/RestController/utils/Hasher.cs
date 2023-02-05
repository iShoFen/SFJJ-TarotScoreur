using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Model.Players;

namespace RestController.utils;

public abstract class Hasher : PasswordHasher<User>
{}