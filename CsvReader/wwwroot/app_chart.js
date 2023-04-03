Papa.parse("test_data.csv", {
  header: true,
  download: true,
  skipEmptyLines: true,
  transform: function (value, header) {
    if (header === "CLUSTER_MEDIAN_PRICE" || header === "CLIENT_MARKET_PRICE") {
      if (!value) {
        return undefined;
      }
    }
    return value; // return the row otherwise
  },
  complete: function (results) {
    const data = results.data.filter(
      (item) =>
        item.CLIENT_MARKET_PRICE !== undefined ||
        item.CLUSTER_MEDIAN_PRICE !== undefined
    );
    var ctx = document.getElementById("gasChart");
    var clusterMediaPrices = data.map((gas) =>
      parseFloat(gas.CLUSTER_MEDIAN_PRICE)
    );
    var clientMarketPrices = data.map((gas) =>
      parseFloat(gas.CLIENT_MARKET_PRICE)
    );
    var siteNames = data.map((gas) => gas.SITE_NAME);

    var myChart = new Chart(ctx, {
      type: "line",
      data: {
        labels: siteNames,
        datasets: [
          {
            label: "Cluster Media Prices",
            data: clusterMediaPrices,
            borderColor: "rgba(255, 99, 132, 1)",
            backgroundColor: "rgba(255, 99, 132, 0.2)",
          },
          {
            label: "Client Market Prices",
            data: clientMarketPrices,
            borderColor: "rgba(54, 162, 235, 1)",
            backgroundColor: "rgba(54, 162, 235, 0.2)",
          },
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  },
  error: function (error) {
    console.error(error);
  },
});
