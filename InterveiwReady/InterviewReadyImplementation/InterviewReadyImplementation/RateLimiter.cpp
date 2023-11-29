// A rate limiter decides if a request should or shouldn't be accepted according to configured service limits
#include <iostream>
using namespace std;

class RateLimiter {

private:
	int wheelSize;
	int BucketSize;
	int currentWheelIndex;
	int currentBucketIndex;

public:
	// Returns whether a request should or shouldn't be accepted according to configured limits
	bool shouldAccept(string requestId, long long timestampInSeconds) {
		//Modulo de timestamp pour savoir sur quel bucket on se trouve
		//Si different du current Bucket, on clear le nouveau bucket
		// On ajoute les éléments jusqu'à la fin du bucket Size
		//On deny tous les autres éléments jusqu'à arriver sur un nouveau bucket

	}

	// Configure request limit for this service
	void configure(int timeOutInSeconds, int capacityPerSecond) {
		BucketSize = capacityPerSecond;
		wheelSize = timeOutInSeconds;
	}
};

