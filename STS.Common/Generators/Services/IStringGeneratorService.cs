using System.Collections.Generic;
using FluentResults;

namespace STS.Common.Generators.Services
{
    public interface IStringGeneratorService
    {
        Result<string> GeneratePassword();

        Result<string> GetRandomString(int length, IEnumerable<char> characterSet);
    }
}