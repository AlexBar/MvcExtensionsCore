namespace FoolproofCore
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class OperatorMetadata
    {
        private static Dictionary<Operator, OperatorMetadata> operatorMetadata;

        static OperatorMetadata()
        {
            CreateOperatorMetadata();
        }

        public string ErrorMessage { get; set; }
        public Func<object, object, bool> IsValid { get; set; }

        public static OperatorMetadata Get(Operator @operator)
        {
            return operatorMetadata[@operator];
        }

        private static void CreateOperatorMetadata()
        {
            operatorMetadata = new Dictionary<Operator, OperatorMetadata>
            {
                {
                    Operator.EqualTo, new OperatorMetadata
                    {
                        ErrorMessage = "equal to",
                        IsValid = (value, dependentValue) =>
                        {
                            if (value == null)
                                return dependentValue == null;

                            return value.Equals(dependentValue);
                        }
                    }
                },
                {
                    Operator.NotEqualTo, new OperatorMetadata
                    {
                        ErrorMessage = "not equal to",
                        IsValid = (value, dependentValue) =>
                        {
                            if (value == null)
                            {
                                return dependentValue != null;
                            }

                            return !value.Equals(dependentValue);
                        }
                    }
                },
                {
                    Operator.GreaterThan, new OperatorMetadata
                    {
                        ErrorMessage = "greater than",
                        IsValid = (value, dependentValue) =>
                        {
                            if (value == null || dependentValue == null)
                                return false;

                            return Comparer<object>.Default.Compare(value, dependentValue) >= 1;
                        }
                    }
                },
                {
                    Operator.LessThan, new OperatorMetadata
                    {
                        ErrorMessage = "less than",
                        IsValid = (value, dependentValue) =>
                        {
                            if (value == null || dependentValue == null)
                                return false;

                            return Comparer<object>.Default.Compare(value, dependentValue) <= -1;
                        }
                    }
                },
                {
                    Operator.GreaterThanOrEqualTo, new OperatorMetadata
                    {
                        ErrorMessage = "greater than or equal to",
                        IsValid = (value, dependentValue) =>
                        {
                            if (value == null && dependentValue == null)
                                return true;

                            if (value == null || dependentValue == null)
                                return false;

                            return Get(Operator.EqualTo).IsValid(value, dependentValue) ||
                                   Comparer<object>.Default.Compare(value, dependentValue) >= 1;
                        }
                    }
                },
                {
                    Operator.LessThanOrEqualTo, new OperatorMetadata
                    {
                        ErrorMessage = "less than or equal to",
                        IsValid = (value, dependentValue) =>
                        {
                            if (value == null && dependentValue == null)
                                return true;

                            if (value == null || dependentValue == null)
                                return false;

                            return Get(Operator.EqualTo).IsValid(value, dependentValue) ||
                                   Comparer<object>.Default.Compare(value, dependentValue) <= -1;
                        }
                    }
                },
                {
                    Operator.RegExMatch, new OperatorMetadata
                    {
                        ErrorMessage = "a match to",
                        IsValid = (value, dependentValue) => Regex.Match((value ?? "").ToString(), dependentValue.ToString()).Success
                    }
                },
                {
                    Operator.NotRegExMatch, new OperatorMetadata
                    {
                        ErrorMessage = "not a match to",
                        IsValid = (value, dependentValue) => !Regex.Match((value ?? "").ToString(), dependentValue.ToString()).Success
                    }
                }
            };
        }
    }
}