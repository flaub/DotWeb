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
