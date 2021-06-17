# Calculator

## Considerations

1. >*Any number of Instructions can be specified.*

    This implies that the input file can be arbitrarily large. We therefore perform each instruction as it is read asynchronously from the file, in order to avoid potentially running out of memory. We  access the last line of the file first, because we need to start with the "apply" instruction. We won't check that the file is valid before we begin processing it. 

1. Although all examples contain integer numbers, we handle fractions. A file could easily contain an instruction that divides an odd number by 2, for example.

1. If we can't parse an input number or operation, we consider the input file invalid and report an error to the console. We need to avoid or handle divide-by-zero errors. We consider the input file invalid on encountering one.

1. Regarding internationalization, the number format would vary according to culture. However, we'd probably need to know the culture in advance rather than try to guess it, and so we assume this is out of scope.

1. Regarding logging, we would normally log using NLog or, these days, Serilog and possibly technology from the ELK stack. This hasn't been implemented, but we do report simple exception text to the console. We also track and report the line number.

1. Sample files are available in the `Calculator.Ui` project, subfolder `SampleFiles`.

