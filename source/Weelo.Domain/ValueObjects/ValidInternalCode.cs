namespace Weelo.Domain.ValueObjects
{
    using System;
    using Weelo.Domain.ValueObjects.Exceptions;

    public sealed class ValidInternalCode : IEquatable<ValidInternalCode>
    {
        private readonly string _value;

        private ValidInternalCode() { }

        public ValidInternalCode(string value)
        {
            if (!value.StartsWith("INT"))
                throw new NotValidInternalCodeException("The 'InternalCode' is not valid.");

            _value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is string)
            {
                return (string) obj == _value;
            }

            return ((ValidInternalCode) obj)._value == _value;
        }

        public bool Equals(ValidInternalCode other)
        {
             return this._value == other._value;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _value.GetHashCode();
                return hash;
            }
        }

        public string Value() { return _value; }
    }
}