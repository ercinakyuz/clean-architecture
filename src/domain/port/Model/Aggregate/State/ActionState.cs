﻿using Company.Framework.Domain.Model.Aggregate.State;

namespace Clean.Domain.Port.Model.Aggregate.State;

public record ActionState(string Value) : CoreState<ActionState>(Value)
{
    public static readonly ActionState Loaded = new("Loaded");

    public static readonly ActionState PingApplied = new("PingApplied");

    public static readonly ActionState PongApplied = new("PongApplied");
}