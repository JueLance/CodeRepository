#include <windows.h>
#include <stdio.h>

#define DIV 1024

char *divisor = "K";

#define WIDTH 7

void main(int argc, char *argv[])
{
  MEMORYSTATUS stat;

  GlobalMemoryStatus (&stat);

  printf ("The MemoryStatus structure is %ld bytes long.\n",
          stat.dwLength);
  printf ("It should be %d.\n", sizeof (stat));
  printf ("%ld percent of memory is in use.\n",
          stat.dwMemoryLoad);
  printf ("There are %*ld total %sbytes of physical memory.\n",
          WIDTH, stat.dwTotalPhys/DIV, divisor);
  printf ("There are %*ld free %sbytes of physical memory.\n",
          WIDTH, stat.dwAvailPhys/DIV, divisor);
  printf ("There are %*ld total %sbytes of paging file.\n",
          WIDTH, stat.dwTotalPageFile/DIV, divisor);
  printf ("There are %*ld free %sbytes of paging file.\n",
          WIDTH, stat.dwAvailPageFile/DIV, divisor);
  printf ("There are %*lx total %sbytes of virtual memory.\n",
          WIDTH, stat.dwTotalVirtual/DIV, divisor);
  printf ("There are %*lx free %sbytes of virtual memory.\n",
          WIDTH, stat.dwAvailVirtual/DIV, divisor);
}
