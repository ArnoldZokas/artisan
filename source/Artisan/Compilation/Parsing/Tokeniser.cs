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
using System;
using System.IO;
using Artisan.Utils;
using Microsoft.Scripting;
using Microsoft.Scripting.Runtime;

namespace Artisan.Compilation.Parsing
{
	public class Tokeniser : TokenizerService
	{
		public override object CurrentState
		{
			get { return null; }
		}

		public override SourceLocation CurrentPosition
		{
			get { throw new NotImplementedException(); }
		}

		public override bool IsRestartable
		{
			get { return false; }
		}

		public override ErrorSink ErrorSink
		{
			get { throw new NotImplementedException(); }
			set
			{
				RuntimeContract.RequiresParameter(value, "value");
				throw new NotImplementedException();
			}
		}

		public override void Initialize(object state, TextReader sourceReader, SourceUnit sourceUnit, SourceLocation initialLocation)
		{
			throw new NotImplementedException();
		}

		public override TokenInfo ReadToken()
		{
			throw new NotImplementedException();
		}
	}
}