﻿using System;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Generators;

namespace RandomDataGenerator.Randomizers;

public abstract class RandomizerAbstract<TOptions> where TOptions : FieldOptionsAbstract
{
    private readonly RandomValueGenerator _randomValueGenerator;
    protected readonly TOptions Options;
        

    protected RandomizerAbstract(TOptions options)
    {
        Options = options;

        _randomValueGenerator = new RandomValueGenerator(Options.Seed ?? Environment.TickCount);
    }

    protected virtual bool IsNull()
    {
        return Options.UseNullValues && _randomValueGenerator.Next(0, 10) == 5; // 10% chance on null
    }
}