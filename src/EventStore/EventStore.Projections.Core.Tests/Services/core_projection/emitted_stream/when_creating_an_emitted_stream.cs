// Copyright (c) 2012, Event Store LLP
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
// 
// Redistributions of source code must retain the above copyright notice,
// this list of conditions and the following disclaimer.
// Redistributions in binary form must reproduce the above copyright
// notice, this list of conditions and the following disclaimer in the
// documentation and/or other materials provided with the distribution.
// Neither the name of the Event Store LLP nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 

using System;
using EventStore.Core.Tests.Bus.Helpers;
using EventStore.Core.Tests.Fakes;
using EventStore.Projections.Core.Messages;
using EventStore.Projections.Core.Services.Processing;
using NUnit.Framework;

namespace EventStore.Projections.Core.Tests.Services.core_projection.emitted_stream
{
    [TestFixture]
    public class when_creating_an_emitted_stream
    {
        [Test, ExpectedException(typeof (ArgumentNullException))]
        public void null_stream_id_throws_argument_null_exception()
        {
            var s = new EmittedStream(
                null, CheckpointTag.FromPosition(0, -1), new FakePublisher(), new TestCheckpointManagerMessageHandler(), 50);
        }

        [Test, ExpectedException(typeof (ArgumentException))]
        public void empty_stream_id_throws_argument_exception()
        {
            var s = new EmittedStream(
                "", CheckpointTag.FromPosition(0, -1), new FakePublisher(), new TestCheckpointManagerMessageHandler(), 50);
        }

        [Test, ExpectedException(typeof (ArgumentNullException))]
        public void null_publisher_throws_argument_null_exception()
        {
            var s = new EmittedStream(
                "test", CheckpointTag.FromPosition(0, -1), null, new TestCheckpointManagerMessageHandler(), 50);
        }

        [Test, ExpectedException(typeof (ArgumentNullException))]
        public void null_ready_handler_throws_argumenbt_null_exception()
        {
            var s = new EmittedStream("test", CheckpointTag.FromPosition(0, -1), new FakePublisher(), null, 50);
        }

        [Test]
        public void it_can_be_created()
        {
            var s = new EmittedStream(
                "test", CheckpointTag.FromPosition(0, -1), new FakePublisher(), new TestCheckpointManagerMessageHandler(), 50);
        }
    }
}
