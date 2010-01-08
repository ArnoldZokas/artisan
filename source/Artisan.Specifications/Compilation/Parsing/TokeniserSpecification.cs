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
using Artisan.Compilation.Parsing;
using Xunit;
using Xunit.Specifications;

namespace Artisan.Specifications.Compilation.Parsing
{
	public class TokeniserSpecification
	{
		[Specification]
		public void ConstructorSpecification()
		{
			Tokeniser tokeniser = null;

			"Given a new Tokeniser".Context(() => tokeniser = new Tokeniser());

			"CurrentState is null".Assert(() => Assert.Null(tokeniser.CurrentState));
		}
	}
}