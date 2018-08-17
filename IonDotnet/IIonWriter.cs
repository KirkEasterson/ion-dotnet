﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace IonDotnet
{
    /// <inheritdoc cref="IValueWriter" />
    /// <summary>
    /// Contains all functions to write an Ion stream
    /// </summary>
    public interface IIonWriter : IValueWriter, IDisposable
    {
        ISymbolTable SymbolTable { get; }

        void Flush();
        
        /// <summary>
        /// Mark the writer as 'finished', all written values will be erased
        /// </summary>
        void Finish();

        /// <summary>
        /// Set the field name, must be called when in a Struct
        /// </summary>
        /// <param name="name">Field name</param>
        void SetFieldName(string name);

        /// <summary>
        /// Set the field name, but as a <see cref="SymbolToken"/>
        /// </summary>
        /// <param name="symbol">Symbol token</param>
        void SetFieldNameSymbol(SymbolToken symbol);

        /// <summary>
        /// Step in a container
        /// </summary>
        /// <param name="type">Container type</param>
        void StepIn(IonType type);

        /// <summary>
        /// Step out of the current container
        /// </summary>
        void StepOut();

        /// <summary>
        /// Whether values are being written as fields of a struct
        /// </summary>
        bool IsInStruct { get; }

        /// <summary>
        /// Write the current value from the reader
        /// </summary>
        /// <param name="reader">Ion reader</param>
        void WriteValue(IIonReader reader);

        /// <summary>
        /// Writes a reader's current value, and all following values until the end of the current container.
        /// If there's no current value then this method calls {@link IonReader#next()} to get going.
        /// </summary>
        /// <param name="reader">Ion reader</param>
        /// <remarks>This method iterates until <see cref="IIonReader.MoveNext"/> returns null and does not Step out</remarks>
        void WriteValues(IIonReader reader);

        /// <summary>
        /// Set the annotations of the current value
        /// </summary>
        /// <param name="annotations">Set of annotations</param>
        void SetTypeAnnotationSymbols(IEnumerable<SymbolToken> annotations);
    }
}
