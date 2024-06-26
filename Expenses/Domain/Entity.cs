﻿namespace Expenses.Domain;

public class Entity<ID>
{
    public ID id { get; set; }
    public override string ToString()
    {
        return "[" + id + "] ";
    }
}