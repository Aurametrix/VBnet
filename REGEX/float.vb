''' regular expression for float value (5,2):

[-+]?[0-9]{0,3}\.?[0-9]{1,2}

''' General matcher for floating point numbers:
[-+]?[0-9]*\.?[0-9]+

^[-+]?[0-9]*\.?[0-9]+$

''' an expression allowing exponents (e.g. -0.1e-9):

[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)? 