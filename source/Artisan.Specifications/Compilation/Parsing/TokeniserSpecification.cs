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
using Artisan.Compilation.Parsing;
using Artisan.Specifications.Utils.Extensions;
using Microsoft.Scripting;
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

			"CurrentState is null".Assert(() => tokeniser.CurrentState.ShouldBeNull());
			"CurrentPosition throws NotImplementedException".Assert(() => Assert.Throws<NotImplementedException>(() => tokeniser.CurrentPosition));
			"ErrorSink throws NotImplementedException".Assert(() => Assert.Throws<NotImplementedException>(() => tokeniser.ErrorSink));
		}

		[Specification]
		public void InitializeSpecification()
		{
			Tokeniser tokeniser = null;

			"Given new Tokeniser".Context(() => tokeniser = new Tokeniser());

			"Initialise throws NotImplementedException".Assert(() => Assert.Throws<NotImplementedException>(() => tokeniser.Initialize(null, null, null, SourceLocation.None)));
		}

		[Specification]
		public void ReadTokenSpecification()
		{
			Tokeniser tokeniser = null;

			"Given new Tokeniser".Context(() => tokeniser = new Tokeniser());

			"ReadToken throws NotImplementedException".Assert(() => Assert.Throws<NotImplementedException>(() => tokeniser.ReadToken()));
		}

		[Specification]
		public void ErrorSinkSpecification()
		{
			Tokeniser tokeniser = null;

			"Given new Tokeniser".Context(() => tokeniser = new Tokeniser());

			"ErrorSink setter throws NotImplementedException".Assert(() => Assert.Throws<NotImplementedException>(() => tokeniser.ErrorSink = ErrorSink.Default));
			"ErrorSink setter throws ArgumentNullException when value passed is null".Assert(() => Assert.Throws<ArgumentNullException>(() => tokeniser.ErrorSink = null));
		}

		[Specification]
		public void IsRestartableSpecification()
		{
			Tokeniser tokeniser = null;

			"Given new Tokeniser".Context(() => tokeniser = new Tokeniser());

			"IsRestartable is false".Assert(() => tokeniser.IsRestartable.ShouldBe(false));
		}
	}
}