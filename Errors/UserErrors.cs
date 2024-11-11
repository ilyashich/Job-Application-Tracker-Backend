namespace JobApplicationTracker.Errors;

public class EmailAlreadyExistsError(string email) : Error($"User with email \"{email}\" already exists.");

public class UsernameAlreadyExistsError(string userName) : Error($"User with username \"{userName}\" already exists.");

public class UsernameDoesNotExistError(string userName) : Error($"User with username \"{userName}\" does not exist.");

public class WrongUserNameOrPasswordError() : Error("Wrong username or password.");

