//  #######################################################
//  
//  # Copyright © Arnold Zokas 2010
//  
//  # This source code is subject to terms and conditions of the Microsoft Public License.
//  # A copy of the license can be found in the license.txt file at the root of this distribution.
//  # If you cannot locate the Microsoft Public License, please send an email to arnold.zokas@coderoom.net.
//  # By using this source code in any fashion, you are agreeing to be bound by the terms of the Microsoft Public License.
//  # You must not remove this notice, or any other, from this software.
//  
//  #######################################################
using Microsoft.Scripting;

namespace Artisan.Compilation.Parsing
{
	public sealed class Token
	{
		public Token(SourceSpan source, TokenTypes type)
		{
			Source = source;
			Type = type;
		}

		public SourceSpan Source { get; private set; }
		public TokenTypes Type { get; private set; }
	}
}