using ErrorOr;

namespace Domain.Errors;

public static class Errors
{
    public static class Auth
    {
        public static Error DuplicatedEmail => Error.Conflict(code: "duplicated_email", description: "Email already exists");
        public static Error DuplicatedUsername => Error.Conflict(code: "duplicated_username", description: "Username already exists");
        public static Error WrongPassword => Error.Unauthorized(code: "wrong_password", description: "Wrong password");
        public static Error UserNotFound => Error.NotFound(code: "user_not_found", description: "User not found");
    }
}