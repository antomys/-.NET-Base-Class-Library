namespace AssemblingCSharpProgram

/// <summary>
/// Module with utilities to transform one weather format in another
/// </summary>
module WeatherUtilities =
    
    /// <summary>
    /// Converts fahrenheit to celsius 
    /// </summary>
    /// <returns> float value of new temperature</returns>
    let fahrenheitToCelsius (temperature : float32) =
        (temperature - 32f) / 1.8f
        
    /// <summary>
    /// Converts celsius to fahrenheit 
    /// </summary>
    /// <returns> float value of new temperature</returns>
    let celsiusToFahrenheit (temperature : float32) =
       (temperature * 1.8f) + 32f
       
    /// <summary>
    /// Calculates comfort index. The higher index, the lower comfort
    /// </summary>
    /// <returns> float value of comfort index.</returns>
    let comfortIndex (temperature : float32) (humidity : float32) =
        (temperature + humidity) / 4f;
