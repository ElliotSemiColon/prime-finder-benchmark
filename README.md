# benchmark by finding primes
this is an implementation of the Sieve of Eratosthenes\
it's run as many times as possible in ~5 seconds to test ***per-thread*** performance\
to try this program out, download the repo and run the executable inside its folder **(only run executables from people you trust)**

## making sense of the result
the higher the number of *iterations*, the faster your cpu and ram\
iterations are reflected by score in points (points are adjusted for the time it took to run the benchmark)

## for context
| processor  | # threads | score (points) |
| ------------- | ------------- | ------------- |
| i5-6600 | 4 | 423 |
| i7-1065G7 | 8 | 789 |
| ryzen 9 3900x | 24 | 767 |
