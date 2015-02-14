public bool SymmetricMatrixInvert(double[,] V)
        {
            int N = (int)Math.Sqrt(V.Length);
            double[] t = new double[N];
            double[] Q = new double[N];
            double[] R = new double[N];
            double AB;
            int K, L, M;

            // Invert a symetric matrix in V
            for (M = 0; M < N; M++)
                R[M] = 1;
            K = 0;
            for (M = 0; M < N; M++)
            {
                double Big = 0;
                for (L = 0; L < N; L++)
                {
                    AB = Math.Abs(V[L, L]);
                    if ((AB > Big) && (R[L] != 0))
                    {
                        Big = AB;
                        K = L;
                    }
                }
                if (Big == 0)
                {
                    return false;
                }
                R[K] = 0;
                Q[K] = 1 / V[K, K];
                t[K] = 1;
                V[K, K] = 0;
                if (K != 0)
                {
                    for (L = 0; L < K; L++)
                    {
                        t[L] = V[L, K];
                        if (R[L] == 0)
                            Q[L] = V[L, K] * Q[K];
                        else
                            Q[L] = -V[L, K] * Q[K];
                        V[L, K] = 0;
                    }
                }
                if ((K + 1) < N)
                {
                    for (L = K + 1; L < N; L++)
                    {
                        if (R[L] != 0)
                            t[L] = V[K, L];
                        else
                            t[L] = -V[K, L];
                        Q[L] = -V[K, L] * Q[K];
                        V[K, L] = 0;
                    }
                }
                for (L = 0; L < N; L++)
                    for (K = L; K < N; K++)
                        V[L, K] = V[L, K] + t[L] * Q[K];
            }
            M = N;
            L = N - 1;
            for (K = 1; K < N; K++)
            {
                M = M - 1;
                L = L - 1;
                for (int J = 0; J <= L; J++)
                    V[M, J] = V[J, M];
            }
            return true;
        }
