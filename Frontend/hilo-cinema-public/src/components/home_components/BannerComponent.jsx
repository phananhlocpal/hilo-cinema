import { useSelector } from 'react-redux';
import { Carousel } from '@material-tailwind/react';

export function CarouselDefault() {
  const carouselImages = useSelector((state) => state.home.carouselImages);

  return (
    <Carousel className="rounded-xl">
      {carouselImages.map((image, index) => (
        <img
          key={index}
          src={image.src}
          alt={`image ${index + 1}`}
          className="h-full w-full object-cover"
        />
      ))}
    </Carousel>
  );
}
