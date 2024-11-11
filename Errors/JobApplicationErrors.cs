namespace JobApplicationTracker.Errors;

public class JobApplicationDoesNotExistError(Guid jobApplicationId): Error($"JobApplication with id {jobApplicationId} does not exist");

public class AuthorizationEditError() : Error("You are not allowed to edit/delete this job application");