import Carousel from "react-multi-carousel";
import "react-multi-carousel/lib/styles.css";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
const PromotionalNewsComponent = () => {
  const promotionNews = useSelector((state) => state.home.promotionalNew);

  const promotionalNews = {
    desktop: {
      breakpoint: { max: 3000, min: 1024 },
      items: 4,
    },
    tablet: {
      breakpoint: { max: 1024, min: 464 },
      items: 2,
    },
    mobile: {
      breakpoint: { max: 464, min: 0 },
      items: 2,
    },
  };

  return (
    <div className="container mx-auto mt-10">
      <Carousel
        autoPlay={true}
        autoPlaySpeed={2000}
        infinite={true}
        showDots={false}
        removeArrowOnDeviceType={["tablet", "mobile", "desktop"]}
        responsive={promotionalNews}
      >
        {promotionNews.map((v, index) => (
          <Link key={index}>
            <div className="text-center mx-2">
              <img src={v.url} alt={v.title} />
              <p className="font-medium text-base mt-2">{v.title}</p>
            </div>
          </Link>
        ))}
      </Carousel>
    </div>
  );
};

export default PromotionalNewsComponent;