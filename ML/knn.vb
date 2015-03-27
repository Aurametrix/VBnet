 // Create some sample learning data. In this data,
    // the first two instances belong to a class, the
    // four next belong to another class and the last
    // three to yet another.

    double[][] inputs = 
    {
        // The first two are from class 0
        new double[] { -5, -2, -1 },
        new double[] { -5, -5, -6 },


        // The next four are from class 1
        new double[] {  2,  1,  1 },
        new double[] {  1,  1,  2 },
        new double[] {  1,  2,  2 },
        new double[] {  3,  1,  2 },


        // The last three are from class 2
        new double[] { 11,  5,  4 },
        new double[] { 15,  5,  6 },
        new double[] { 10,  5,  6 },
    };

    int[] outputs =
    {
        0, 0,        // First two from class 0
        1, 1, 1, 1,  // Next four from class 1
        2, 2, 2      // Last three from class 2
    };


    // Now we will create the K-Nearest Neighbors algorithm. For this
    // example, we will be choosing k = 4. This means that, for a given
    // instance, its nearest 4 neighbors will be used to cast a decision.
    KNearestNeighbor knn = new KNearestNeighbor(k: 4, classes: 3,
        inputs: inputs, outputs: outputs);


    // After the algorithm has been created, we can classify a new instance:
    int answer = knn.Compute(new double[] { 11, 5, 4 }); // answer will be 2.
