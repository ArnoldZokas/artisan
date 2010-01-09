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
using Artisan.Compilation.Parsing;
using Artisan.Specifications.Utils.Extensions;
using Microsoft.Scripting;
using Xunit;
using Xunit.Specifications;

namespace Artisan.Specifications.Compilation.Parsing
{
	public class TokeniserSpecification
	{
		#region Property Specifications

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

		#endregion

		#region Method Specifications

		[Specification]
		public void ConstructorSpecification()
		{
			Tokeniser tokeniser = null;

			"Given a new Tokeniser".Context(() => tokeniser = new Tokeniser());

			"CurrentState is null".Assert(() => tokeniser.CurrentState.ShouldBeNull());
			"CurrentPosition is SourceLocation.None".Assert(() => tokeniser.CurrentPosition.ShouldBe(SourceLocation.None));
			"ErrorSink throws NotImplementedException".Assert(() => Assert.Throws<NotImplementedException>(() => tokeniser.ErrorSink));
		}

		[Specification]
		public void InitializeSpecification()
		{
			var reader = new StringReader("");
			Tokeniser tokeniser = null;

			"Given new Tokeniser".Context(() => tokeniser = new Tokeniser());
			"with Initialise() called".Do(() => tokeniser.Initialize(reader));

			"Initialise throws ArgumentNullException when sourceReader passed is null".Assert(() => Assert.Throws<ArgumentNullException>(() => tokeniser.Initialize(null)));
		}

		#region ReadToken Specifications

		[Specification]
		public void ReadTokenSpecification_ForEmptyString()
		{
			Tokeniser tokeniser = null;

			"Given new Tokeniser initialised with empty string".Context(() => tokeniser = new Tokeniser());
			"with Initialise() called".Do(() => tokeniser.Initialize(new StringReader(string.Empty)));

			"ReadToken returns TokenInfo where Category is TokenCategory.None".Assert(() => tokeniser.ReadToken().Category.ShouldBe(TokenCategory.EndOfStream));
			"ReadToken returns TokenInfo where Trigger is TokenTriggers.None".Assert(() => tokeniser.ReadToken().Trigger.ShouldBe(TokenTriggers.None));
			"ReadToken returns TokenInfo where SourceSpan is SourceSpan.None".Assert(() => tokeniser.ReadToken().SourceSpan.ShouldBe(SourceSpan.None));
		}

		[Specification]
		public void ReadTokenSpecification_ForValidVariableDeclaration()
		{
			Tokeniser tokeniser = null;

			"Given new Tokeniser initialised with \"var\"".Context(() => tokeniser = new Tokeniser());
			"with Initialise() called".Do(() => tokeniser.Initialize(new StringReader("var")));

			"ReadToken returns TokenInfo where Category is TokenCategory.None".Assert(() => tokeniser.ReadToken().Category.ShouldBe(TokenCategory.Keyword));
			"ReadToken returns TokenInfo where Trigger is TokenTriggers.None".Assert(() => tokeniser.ReadToken().Trigger.ShouldBe(TokenTriggers.None));
			"ReadToken returns TokenInfo where SourceSpan is SourceSpan.None".Assert(() => tokeniser.ReadToken().SourceSpan.ShouldBe(new SourceSpan(new SourceLocation(0, 1, 1), new SourceLocation(0, 1, 3))));
		}

		#endregion

		#endregion
	}
}