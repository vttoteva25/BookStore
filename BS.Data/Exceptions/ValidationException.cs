﻿namespace BS.Data.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public ValidationException(string propertyName, string message)
            : this()
        {
            Errors = new Dictionary<string, string[]> { { propertyName, new[] { message } } };
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
