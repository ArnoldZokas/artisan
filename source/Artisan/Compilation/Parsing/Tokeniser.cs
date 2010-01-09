//  #######################################################
//  
//  # Copyright (C) Arnold Zokas 2010
//  
//  # This source code is subject to terms and conditions of the Microsoft Public License.
//  # A copy of the license can be found in the license.txt file at the root of this distribution.
//  # If you cannot locate the Microsoft Public License, please send an email to arnold.zokas@coderoom.net.
//  # By using this source code in any fashion, you are agreeing to be bound by the terms of the Microsoft Public License.
//  # You must not remove this notice, or any other, from this software.
//  
//  #######################################################
using System;
using System.IO;
using Artisan.Utils;
using Microsoft.Scripting;

namespace Artisan.Compilation.Parsing
{
	public class Tokeniser
	{
		private char[] _currentLine;
		private SourceLocation _currentPosition;
		private SourceLocation _initialPosition;
		private TextReader _reader;

		public Tokeniser()
		{
			_currentPosition = SourceLocation.None;
		}

		public SourceLocation CurrentPosition
		{
			get { return _currentPosition; }
		}

		public void Initialize(TextReader sourceReader)
		{
			RuntimeContract.RequiresParameter(sourceReader, "sourceReader");

			_reader = sourceReader;
		}

		public Token ReadToken()
		{
			if (_reader.Peek() == -1)
				return new Token(SourceSpan.None, TokenTypes.EndOfFile);

			if (_currentPosition == SourceLocation.None) // TODO: move this
				_currentPosition = new SourceLocation(0, 1, 1);

			_initialPosition = _currentPosition;

			int currentColumn = _currentPosition.Column;

			_currentLine = _reader.ReadLine().ToCharArray();

			while (currentColumn <= _currentLine.Length)
			{
				char currentChar = _currentLine[currentColumn - 1];
				_currentPosition = new SourceLocation(0, _currentPosition.Line, currentColumn + 1);

				switch (currentChar)
				{
					default:
						if (MatchesIdentifierStart(currentChar))
							return GetIdentifier(currentChar, currentColumn + 1);

						throw new NotImplementedException();
				}
			}

			throw new NotImplementedException();
		}

		private Token GetIdentifier(char firstChar, int currentColumn)
		{
			string identifier = firstChar.ToString();

			while (currentColumn <= _currentLine.Length)
			{
				char currentChar = _currentLine[currentColumn - 1];
				currentColumn++;
				_currentPosition = new SourceLocation(0, _currentPosition.Line, currentColumn - 1);

				identifier += currentChar.ToString();
				// TODO: check that identifier matches a keyword
			}

			return new Token(new SourceSpan(new SourceLocation(_initialPosition.Index, _initialPosition.Line, _initialPosition.Column), new SourceLocation(_currentPosition.Index, _currentPosition.Line, currentColumn - 1)), TokenTypes.Var);
		}

		private static bool MatchesIdentifierStart(char current)
		{
			return current == 'v';
		}
	}
}