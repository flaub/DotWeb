// Copyright 2009, Frank Laub
//
// This file is part of DotWeb.
//
// DotWeb is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// DotWeb is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with DotWeb.  If not, see <http://www.gnu.org/licenses/>.

#ifndef __Types_H__
#define __Types_H__

#ifdef _WINDOWS

typedef signed char         int8;
typedef unsigned char       uint8;
typedef short               int16;
typedef unsigned short      uint16;
typedef int                 int32;
typedef unsigned int        uint32; 

#ifdef _MSC_VER
typedef __int64             int64;
typedef unsigned __int64    uint64;
#else
typedef long long           int64;
typedef unsigned long long  uint64;
#endif /* _MSC_VER */

typedef int8 int8_t;
typedef uint8 uint8_t;

typedef int16 int16_t;
typedef uint16 uint16_t;

typedef int32 int32_t;
typedef uint32 uint32_t;

typedef int64 int64_t;
typedef uint64 uint64_t;

#endif

#endif
