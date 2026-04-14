using Microsoft.AspNetCore.Authorization;

public class AdminOverrideHandler : IAuthorizationHandler
{
    public Task HandleAsync(AuthorizationHandlerContext context)
    {
        if (context.User.IsInRole("Super Admin"))
        {
            foreach (var requirement in context.Requirements)
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }
}