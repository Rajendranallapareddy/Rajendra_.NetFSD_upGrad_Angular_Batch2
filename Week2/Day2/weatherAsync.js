const latitude = 17.3850;
const longitude = 78.4867;

const url = `https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`;

const fetchWeather = async () => {
    try {

        const response = await fetch(url);

        if (!response.ok) {
            throw new Error("Failed to fetch weather data");
        }

        const data = await response.json();

        const { temperature, windspeed, winddirection } = data.current_weather;

        const report = `
========================
      WEATHER REPORT
========================
Temperature   : ${temperature}°C
Wind Speed    : ${windspeed} km/h
Wind Direction: ${winddirection}°
========================
`;

        console.log(report);

    } catch (error) {
        console.error("Weather Fetch Error:", error.message);
    }
};

fetchWeather();