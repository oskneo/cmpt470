
void compute_ranks(float *F, int N, int *R, float *avg, float *passing_avg, int *num_passed) {
    int i, j;
    int limit=(N/2)*2;
    //Get the largest multiple of 4 less than N for the limit of loop unrolling
    int newavg=0;
    int newpassing_avg = 0;
    int newnum_passed=0;
    //Create an int to remember the least continuous rank counted from largest 
    int t=N-1;

    //Combine the three loops into one loop to save time on adding counter
    for (i=0; i < N; i++) { 
        R[i] = 1;
        //In loop unrolling, add more than 1 to counter
        for (j = 0; j < limit; j+=2) {
        //Reduce times to loop by writing statements for j, j+1, j+2, j+3 in 1 loop
            if (F[i] < F[j]) {
                R[i] += 1;
            }
            if (F[i] < F[j+1]) {
                R[i] += 1;
            }
            //When the current rank is equal to t, 
            //there is no possibility a rank greater than current,
            //reduce the t by 1 and break
            if(R[i]==t){
                j=N;
                t--;
            }
        }
        for (;j < N; j++) {
            if (F[i] < F[j]) {
                R[i] += 1;
            }
        }
        //Reduce the memory aliasing by 
        //not using pointers in calculation in loop 
        newavg += F[i];
        if (F[i] >= 50.0) {
            newpassing_avg += F[i];
            newnum_passed += 1;
        }
    }


    // check for div by 0
    if (N > 0) *avg = (float)newavg/ N;
    if (newnum_passed) *passing_avg =(float)newpassing_avg/ newnum_passed;
    
    *num_passed=newnum_passed;
    //Assign the value back to pointers


} // compute_ranks

