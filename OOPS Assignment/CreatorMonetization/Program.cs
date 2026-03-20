using OOPSAssignment.CreatorMonetization.Domain.Entities;
using OOPSAssignment.CreatorMonetization.Domain.Services;
using OOPSAssignment.CreatorMonetization.Domain.Strategies;

Console.WriteLine("=== Creator Monetization (Refactored) ===\n");

Console.WriteLine("Single source: ADS (views * 0.05)");
var adsEntity = new CreatorEntity("CreatorA", views: 1000, subscribers: 0, baseAmount: 0);
var adsService = new CreatorEarningsService();
adsService.RegisterEarningStrategy(new AdsEarningStrategy());
Console.WriteLine($"  Earnings: {adsService.CalculateEarnings(adsEntity)}\n");

Console.WriteLine("Single source: SUBSCRIPTION (subscribers * 2)");
var subEntity = new CreatorEntity("CreatorB", views: 0, subscribers: 50, baseAmount: 0);
var subService = new CreatorEarningsService();
subService.RegisterEarningStrategy(new SubscriptionEarningStrategy());
Console.WriteLine($"  Earnings: {subService.CalculateEarnings(subEntity)}\n");

Console.WriteLine("Single source: BRAND (baseAmount)");
var brandEntity = new CreatorEntity("CreatorC", views: 0, subscribers: 0, baseAmount: 2500);
var brandService = new CreatorEarningsService();
brandService.RegisterEarningStrategy(new BrandEarningStrategy());
Console.WriteLine($"  Earnings: {brandService.CalculateEarnings(brandEntity)}\n");

Console.WriteLine("Multiple sources: ADS + SUBSCRIPTION + BRAND");
var multiEntity = new CreatorEntity("CreatorD", views: 2000, subscribers: 100, baseAmount: 500);
var multiService = new CreatorEarningsService();
multiService.RegisterEarningStrategy(new AdsEarningStrategy());
multiService.RegisterEarningStrategy(new SubscriptionEarningStrategy());
multiService.RegisterEarningStrategy(new BrandEarningStrategy());
Console.WriteLine($"  Earnings: {multiService.CalculateEarnings(multiEntity)}\n");

Console.WriteLine("=== Demo Complete ===");
