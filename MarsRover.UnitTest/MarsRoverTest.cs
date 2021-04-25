using FluentAssertions;
using MarsRover.Core;
using MarsRover.Core.Validators;
using MarsRover.Core.Vectors;
using System;
using Xunit;

namespace MarsRover.UnitTest
{
    public class MarsRoverTest
    {
        [Theory]
        [InlineData("LLLMMMRRR")]
        [InlineData("LMLMLMLM")]
        [InlineData("MMMRRRLLL")]
        public void RoverCommands_Should_Be_True(string commands)
        {
            var result = Validator.ValidateRoverCommands(commands);
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("LRCCCL")]
        [InlineData("CLKME")]
        [InlineData("12312312")]
        [InlineData("")]
        [InlineData(null)]
        public void RoverCommands_Should_Be_False(string commands)
        {
            var result = Validator.ValidateRoverCommands(commands);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("2 2 N")]
        [InlineData("5 5 S")]
        [InlineData("2 3 E")]
        public void RoverPosition_Should_Be_True(string roverPosition)
        {
            var result = Validator.ValidateRoverPosition(roverPosition);
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("2 2 C")]
        [InlineData("3 C N")]
        [InlineData("3  3 N")]
        [InlineData("")]
        [InlineData(null)]
        public void RoverPosition_Should_Be_False(string roverPosition)
        {
            var result = Validator.ValidateRoverPosition(roverPosition);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("5 5")]
        [InlineData("2 2")]
        [InlineData("4 8")]
        public void PlateauBoundaries_Should_Be_True(string boundaries)
        {
            var result = Validator.ValidatePlateauBoundaries(boundaries);
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("2  2")]
        [InlineData("3 C")]
        [InlineData("3 5 ")]
        [InlineData("")]
        [InlineData(null)]
        public void PlateauBoundaries_Should_Be_False(string boundaries)
        {
            var result = Validator.ValidatePlateauBoundaries(boundaries);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void CalculateRoverDirection_Should_Be_Valid(string plateauBoundaries, string roverPosition, string commands, string actual)
        {
            var plateauBoundaryArray = plateauBoundaries.Split(" ");
            var roverLocationArray = roverPosition.Split(" ");

            Plateau plateau = new Plateau();
            plateau.Boundary = new Tuple<int, int>(Convert.ToInt32(plateauBoundaryArray[0]), Convert.ToInt32(plateauBoundaryArray[1]));

            var rover = new Rover(plateau);
            rover.commands = commands.ToCharArray();
            rover.location.X = Convert.ToInt32(roverLocationArray[0]);
            rover.location.Y = Convert.ToInt32(roverLocationArray[1]);
            rover.direction = roverLocationArray[2].ToDirection();

            var result = rover.Run();

            result.Should().Equals(actual);
        }
    }
}