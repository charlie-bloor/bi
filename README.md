# Calculator

## Considerations

1. "Any number of Instructions can be specified" in the file. We might prefer to read the entire file into memory in order to minimize the time the file is open for reading. But if the file can be arbitrarily large we might prefer to perform each calculation as it is read, in order to avoid potentially running out of memory. This also means we won't check that the file is valid before we begin processing it. We also need to consider that the number we'd orindarily start with is at the end of the file.

1. Although all examples contain integer numbers, we shall handle fractions. A file could easily contain an instruction that divides an odd number by 2, for example.

1. We need to avoid or handle divide-by-zero errors. We shall consider the file invalid on encountering one.

1. We should similarly avoid or handle arithmetic overflow. We could handle very large (and small!) numbers by using `float` or `double`. However, these types sacrifice precision for range, which is probably undesirable. It might be reasonable to approach a business analyst, product owner or customer at this point. For now, we assume it is safe to handle an `OverflowException` resulting from a problem with calculations involving the `decimal` type. We shall consider the input file invalid on encountering such an error.

1. Internationalization: the number format would vary according to culture. However, we'd probably need to know the culture in advance rather than try to guess it, and so we assume this is out of scope.

