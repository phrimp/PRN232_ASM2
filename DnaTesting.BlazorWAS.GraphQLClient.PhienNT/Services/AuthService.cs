using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.GraphQLClient;
using DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Models;

namespace DnaTesting.BlazorWAS.GraphQLClient.PhienNT.Services
{
    public class AuthService
    {
        private readonly GraphQLConsumer _graphQLConsumer;
        private UserAccount _currentUser;

        public AuthService(GraphQLConsumer graphQLConsumer)
        {
            _graphQLConsumer = graphQLConsumer;
        }

        public UserAccount CurrentUser => _currentUser;
        public bool IsLoggedIn => _currentUser != null;

        public async Task<LoginResponse> LoginAsync(string username, string password)
        {
            var result = await _graphQLConsumer.LoginAsync(username, password);

            if (result.Success && result.User != null)
            {
                _currentUser = result.User;
            }

            return result;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}