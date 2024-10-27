// Copyright (c) Microsoft. All rights reserved.
// Copyright (c) Ikpil Choi ikpil@naver.com All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace UniNetty.Buffers.Tests
{
    public sealed class PooledDirectByteBufferTests : AbstractPooledByteBufferTests
    {
        protected override IByteBuffer Alloc(int length, int maxCapacity) => PooledByteBufferAllocator.Default.DirectBuffer(length, maxCapacity);
    }
}