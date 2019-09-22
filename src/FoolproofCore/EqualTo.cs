﻿namespace FoolproofCore
{
    public class EqualToAttribute : IsAttribute
    {
        public EqualToAttribute(string dependentProperty) : base(Operator.EqualTo, dependentProperty) { }
    }
}
