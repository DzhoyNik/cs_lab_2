#include <iostream>
using namespace std;

int main() {
	double T = 1873;
	double Si[]{ 0.025, 0.05, 0.075, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7 };
	double O;
	int a = 0;

	while (a < size(Si))
	{

		O = sqrt((pow(10, (-31000 / T + 12.152))) / Si[a]);

		cout.precision(5);
		cout.setf(ios::fixed);
		cout << Si[a] << " " << O << endl;

		a++;
	}
}