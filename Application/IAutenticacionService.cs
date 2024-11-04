

using Application.Models;

namespace Application
{
    public interface IAutenticacionService
    {
        ResponseDto Authenticate(QuestionDto request);
    }
}
